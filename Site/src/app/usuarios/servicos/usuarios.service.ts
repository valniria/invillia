import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppInitService } from '../../compartilhado/servicos/app-init.service';
import { Observable } from 'rxjs';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {
  protected readonly variavelDeAmbiente;
  constructor(
    private appInitService: AppInitService,
    private httpClient: HttpClient
  ) {
    this.appInitService.carregarConfiguracoesDoApp();
    this.variavelDeAmbiente = this.appInitService.retornarConfiguracao();
  }

  cadastrarUsuario(formulario): Observable<any> {
    const requestURL = this.variavelDeAmbiente.APIUrlBase + `usuarios`;
    const parametroPost = {
        nome: formulario.nome,
        status: parseInt(formulario.status),
        email: formulario.email,
        senha: formulario.senha
    };
    return this.httpClient.post(requestURL, parametroPost);
    }

    listarTodosUsuarios(): Observable<any> {
        return this.httpClient.get(this.variavelDeAmbiente.APIUrlBase + `usuarios`);
    }

    obterUsuarioPorId(usuarioId): Observable<any> {
      return this.httpClient.get(this.variavelDeAmbiente.APIUrlBase + `usuarios/` + usuarioId);
    }
}
