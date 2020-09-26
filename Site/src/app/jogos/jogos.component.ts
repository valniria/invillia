import { Component, OnInit } from '@angular/core';
import { JogosModelo} from './modelos/jogos.model';
import { Router } from '@angular/router';
import { JogosService } from './servicos/jogos.service';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.css']
})
export class JogosComponent implements OnInit {
  public listaDeJogos: Array<JogosModelo>;

  constructor(
    private router: Router,
    private servico: JogosService
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

  emprestarJogo(){

  }

  receberJogo(){

  }
}
