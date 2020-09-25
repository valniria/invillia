import { Component, OnInit } from '@angular/core';
import { JogosModelo } from '../modelos/jogos.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jogos-novo',
  templateUrl: './jogos-novo.component.html',
  styleUrls: ['./jogos-novo.component.css']
})
export class JogoNovoComponent implements OnInit {
  formularioJogo:JogosModelo;
  jogoId:number;
  
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  voltarParaListagem(){    
    this.router.navigate(['/jogos']);
  }

  salvarNovoJogo(){

  }

  atualizarJogo(){

  }
}
