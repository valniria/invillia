import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { JogosService } from '../servicos/jogos.service';

@Component({
  selector: 'app-jogo-detalhes',
  templateUrl: './jogo-detalhes.component.html',
  styleUrls: ['./jogo-detalhes.component.css']
})
export class JogoDetalhesComponent implements OnInit {
  dadosDoJogo: any = {
    nome:'', 
    tipoJogoNome:'',
    tipoPlataformaNome:'',
    situacaoNome:'',
    status:null
  }
  dadosUsuario: any ={
    nome:'',
    email:'',
    quantidadeJogosEmprestados:null,
    status:null
  }
  jogo
  constructor(
    private router: Router,
    private servico: JogosService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.obterDadosPelaRota();
  }

  obterDadosPelaRota(){
    this.activatedRoute.params.subscribe(
      (res) => {
        this.obterJogoPorId(res.jogoId);
      },
      (error) =>{
        console.log('Erro no Listar Detalhes do Jogo');
      });
  }

  voltarParaListagem(){    
    this.router.navigate(['/jogos']);
  }

  obterJogoPorId(jogoId){
    this.servico.obterJogo(jogoId).subscribe(
      (res) => {
        debugger;
        this.dadosDoJogo = res.data;
        //this.dadosUsuario = res.data; //pegar apenas o usuario
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }
}
