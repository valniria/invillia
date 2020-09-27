import { Component, OnInit } from '@angular/core';
import { JogosModelo } from '../modelos/jogos.model';
import { Router, ActivatedRoute } from '@angular/router';
import { JogosService } from '../servicos/jogos.service';
import { LoadingService } from 'src/app/compartilhado/servicos/loading.service';

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
    private loadingService: LoadingService,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.obterDadosPelaRota();
  }

  obterDadosPelaRota(){
    this.loadingService.mostrarLoading();
    this.activatedRoute.params.subscribe(
      (res) => {
        this.obterJogo(res.jogoId);
        this.loadingService.removerLoading();
      },
      (error) =>{
        this.loadingService.removerLoading();
      });
  }

  voltarParaListagem(){    
    this.router.navigate(['/jogos']);
  }

  salvarNovoJogo(){
    this.loadingService.mostrarLoading();
    this.servico.cadastrarJogo(this.formularioJogo).subscribe(
      (res) => {
        this.loadingService.removerLoading();
        this.router.navigate(['/jogos']);
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  obterJogo(jogoId){
    this.loadingService.mostrarLoading();
    this.servico.obterJogo(jogoId).subscribe(
      (res) => {
        this.formularioJogo = res.data;
        this.loadingService.removerLoading();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }

  atualizarJogo(){

  }
}
