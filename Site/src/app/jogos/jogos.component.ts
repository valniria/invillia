import { Component, OnInit } from '@angular/core';
import { JogosModelo} from './modelos/jogos.model';
import { Router } from '@angular/router';
import { JogosService } from './servicos/jogos.service';
import { UsuariosService } from '../usuarios/servicos/usuarios.service';
import { LoadingService } from '../compartilhado/servicos/loading.service';
import { MensagemComponent } from '../compartilhado/componentes/mensagem/mensagem.component';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.css']
})
export class JogosComponent implements OnInit {
  public listaDeJogos: Array<JogosModelo>;
  listaDeUsuarios:any;
  usuarioSelecionado: any = {
    id : null,
    nome : ''
  }
  jogoId:number;
  alertarUsuario = {
    exibir: false,
    sucesso: false,
    mensagem: ''
  };

  constructor(
    private router: Router,
    private servico: JogosService,
    private loadingService: LoadingService,
    private usuarioServico: UsuariosService,
    private mensagem: MensagemComponent
    ) { }

  ngOnInit(): void {
    this.listarJogos();
  }

  listarJogos(){
    this.loadingService.mostrarLoading();
    this.servico.listarJogos().subscribe(
      (res) => {
        this.listaDeJogos = res.data;
        this.loadingService.removerLoading();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  cadastrarNovoJogo(){
    this.router.navigate(['/jogo-novo']);
  }

  editarJogo(jogoId){
    this.router.navigate(['/jogo-novo/' + jogoId]);
  }

  carregarDadosDaModalDeEmprestimo(jogoId){
    this.loadingService.mostrarLoading();
    this.jogoId = jogoId;
    this.usuarioServico.listarTodosUsuarios().subscribe(
      (res) => {
        this.listaDeUsuarios = res.data;
        this.loadingService.removerLoading();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  registrarEmprestimo(jogoId:number, usuarioId:number){
    debugger;
    this.loadingService.mostrarLoading();
    this.servico.registrarEmprestimoOuDevolucao(jogoId, usuarioId, 'emprestar').subscribe(
      (res) => {
        this.listaDeJogos = res.data;
        this.loadingService.removerLoading();
        this.router.navigate(['jogos']);
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  registrarDevolucao(jogoId:number, usuarioId:number){
    debugger;
    this.loadingService.mostrarLoading();
    this.servico.registrarEmprestimoOuDevolucao(jogoId, usuarioId, 'devolver').subscribe(
      (res) => {
        this.listaDeJogos = res.data;
        this.loadingService.removerLoading();
        this.listarJogos();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  excluirJogo(jogoId){
    this.loadingService.mostrarLoading();
    this.servico.removerJogo(jogoId).subscribe(
      (res) => {
        this.alertarUsuario = {
          exibir: true,
          sucesso: false,
          mensagem: res.mensagem
        };
        this.loadingService.removerLoading();
        this.listarJogos();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  verDetalhes(jogoId){
    this.router.navigate(['jogo-detalhes/'+jogoId]);
  }
}
