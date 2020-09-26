import { Component, OnInit } from '@angular/core';
import { JogosModelo} from './modelos/jogos.model';
import { Router } from '@angular/router';
import { JogosService } from './servicos/jogos.service';
import { UsuariosService } from '../usuarios/servicos/usuarios.service';

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

  constructor(
    private router: Router,
    private servico: JogosService,
    private usuarioServico: UsuariosService
    ) { }

  ngOnInit(): void {
    this.listarJogos();
  }

  listarJogos(){
    debugger;
    this.servico.listarJogos().subscribe(
      (res) => {
        debugger;
        this.listaDeJogos = res.data;
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  cadastrarNovoJogo(){
    this.router.navigate(['/jogo-novo']);
  }

  editarJogo(jogoId){
    this.router.navigate(['/jogo-novo/'+jogoId]);
  }

  carregarDadosDaModalDeEmprestimo(jogoId){
    debugger;
    this.jogoId = jogoId;
    this.usuarioServico.listarTodosUsuarios().subscribe(
      (res) => {
        debugger;
        this.listaDeUsuarios = res.data;
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  registrarEmprestimo(jogoId:number, usuarioId:number){
    debugger;
    this.servico.registrarEmprestimo(jogoId, usuarioId).subscribe(
      (res) => {
        debugger;
        this.listaDeJogos = res.data;
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  receberJogo(){

  }
}
