import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosModel } from './modelos/usuarios.model';
import { UsuariosService } from './servicos/usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  public listaDeUsuarios: Array<UsuariosModel>;
  formularioUsuario:any;

  constructor(
    private router: Router,
    private servico: UsuariosService

  ) { }

  ngOnInit(): void {
    this.listarTodosUsuarios();
  }

  listarTodosUsuarios(){
    debugger;
    this.servico.listarTodosUsuarios().subscribe(
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

  cadastrarUsuario(){
    this.router.navigate(['usuario-novo']);
  }

  editarUsuario(jogoId){

  }

  excluirUsuario(jogoId){

  }

  verDetalhes(jogoId){

  }
}
