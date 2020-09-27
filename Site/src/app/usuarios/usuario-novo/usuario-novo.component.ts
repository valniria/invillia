import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosService } from '../servicos/usuarios.service';

@Component({
  selector: 'app-usuario-novo',
  templateUrl: './usuario-novo.component.html',
  styleUrls: ['./usuario-novo.component.css']
})
export class UsuarioNovoComponent implements OnInit {
  public formularioUsuario:any = {
    nome: '',
    status: null,
    email: '',
    senha: ''
  }
  usuarioId:number;
  constructor(
    private router: Router,
    private servico: UsuariosService
    ) { }

  ngOnInit(): void {
  }

  voltarParaListagem(){
    this.router.navigate(['/usuarios']);
  }

  salvarNovoUsuario(){
    debugger;
    this.servico.cadastrarUsuario(this.formularioUsuario).subscribe(
      (res) => {
        debugger;
        this.router.navigate(['/usuarios']);
      },
      (error) => {
        console.log('erro');
      }
    );
  }

  atualizarUsuario(){

  }
}
