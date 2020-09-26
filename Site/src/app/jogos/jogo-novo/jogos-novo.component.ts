import { Component, OnInit } from '@angular/core';
import { JogosModelo } from '../modelos/jogos.model';
import { Router, ActivatedRoute } from '@angular/router';
import { JogosService } from '../servicos/jogos.service';

@Component({
  selector: 'app-jogos-novo',
  templateUrl: './jogos-novo.component.html',
  styleUrls: ['./jogos-novo.component.css']
})
export class JogoNovoComponent implements OnInit {
  formularioJogo:any = {
    id: null,
    nome: '',
    tipoJogo: null,
    plataforma: null,
    status: null,
  }
  jogoId:number;
  
  constructor(
    private router: Router,
    private servico: JogosService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    debugger
    this.obterDadosPelaRota();
  }

  obterDadosPelaRota(){
    this.activatedRoute.params.subscribe(
      (res) => {
        this.obterJogo(res.jogoId);
      },
      (error) =>{
        console.log('Erro no Editar Jogo');
      });
  }

  voltarParaListagem(){    
    this.router.navigate(['/jogos']);
  }

  salvarNovoJogo(){
    debugger;
    this.servico.cadastrarJogo(this.formularioJogo).subscribe(
      (res) => {
        debugger;
        this.router.navigate(['/jogos']);
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  obterJogo(jogoId){
    this.servico.obterJogo(jogoId).subscribe(
      (res) => {
        debugger;
        this.formularioJogo = res.data;
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  atualizarJogo(){

  }
}
