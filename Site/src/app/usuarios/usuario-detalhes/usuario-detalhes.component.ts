import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuariosService } from '../servicos/usuarios.service';

@Component({
  selector: 'app-usuario-detalhes',
  templateUrl: './usuario-detalhes.component.html',
  styleUrls: ['./usuario-detalhes.component.css']
})
export class UsuarioDetalhesComponent implements OnInit {
  dadosUsuario: any ={
    nome:'',
    email:'',
    quantidadeJogosEmprestados:null,
    status:null
  }
  jogosDoUsuairo: any = {
    nome:'', 
    tipoJogoNome:'',
    tipoPlataformaNome:'',
    situacaoNome:'',
    status:null
  }
  constructor(
    private router: Router,
    private servico: UsuariosService,
    private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.obterDadosPelaRota();
  }

  obterDadosPelaRota(){
    this.activatedRoute.params.subscribe(
      (res) => {
        this.obterUsuarioPorId(res.usuarioId);
      },
      (error) =>{
        console.log('Erro no Listar Detalhes do Usuário');
      });
  }

  voltarParaListagem(){    
    this.router.navigate(['/usuarios']);
  }

  obterUsuarioPorId(usuarioId){
    this.servico.obterUsuarioPorId(usuarioId).subscribe(
      (res) => {
        debugger;
        this.dadosUsuario = res.data;
        //this.jogosDoUsuairo = res.data; //pegar apenas o jogo
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }

}
