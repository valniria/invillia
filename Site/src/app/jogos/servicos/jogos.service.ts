import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppInitService } from '../../compartilhado/servicos/app-init.service';
import { Observable } from 'rxjs';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';

@Injectable({
  providedIn: 'root'
})
export class JogosService {
  protected readonly variavelDeAmbiente;
  constructor(
    private appInitService: AppInitService,
    private httpClient: HttpClient
  ) {
    this.appInitService.carregarConfiguracoesDoApp();
    this.variavelDeAmbiente = this.appInitService.retornarConfiguracao();
  }

  listarJogos(): Observable<any> {
    return this.httpClient.get(this.variavelDeAmbiente.APIUrlBase + `jogos`);
  }

  cadastrarJogo(formulario): Observable<any> {
    const requestURL = this.variavelDeAmbiente.APIUrlBase + `jogos`;
    const parametroPost = {
      nome: formulario.nome,
      status: parseInt(formulario.status),
      tipoPlataformaId: parseInt(formulario.plataforma),
      tipoJogoId: parseInt(formulario.tipoJogo)
    };
    return this.httpClient.post(requestURL, parametroPost);
  }

  obterJogo(jogoId): Observable<any> {
    return this.httpClient.get(this.variavelDeAmbiente.APIUrlBase + `jogos/` + jogoId);
  }

  registrarEmprestimoOuDevolucao(jogoId, usuarioId, acao): Observable<any> {
    const requestURL = this.variavelDeAmbiente.APIUrlBase + `jogos/emprestarOuReceber`;
    const parametroPut = {
      usuarioId,
      id: jogoId,
      acao
    };
    return this.httpClient.put(requestURL, parametroPut);
  }

  removerJogo(jogoId): Observable<any> {    
      return this.httpClient.delete(this.variavelDeAmbiente.APIUrlBase + `jogos/` + jogoId);
  }
}