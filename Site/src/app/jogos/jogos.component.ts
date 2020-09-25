import { Component, OnInit } from '@angular/core';
import { JogosModelo} from './modelos/jogos.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.css']
})
export class JogosComponent implements OnInit {
  public listaDeJogos: Array<JogosModelo>;

  constructor(
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  cadastrarNovoJogo(){
    this.router.navigate(['/jogo-novo']);
  }

  editarJogo(){

  }

  emprestarJogo(){

  }

  receberJogo(){

  }
}
