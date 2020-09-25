import { Component, OnInit } from '@angular/core';
import { UsuariosModel } from './modelos/usuarios.model';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  public listaDeUsuarios: Array<UsuariosModel>;

  constructor() { }

  ngOnInit(): void {
  }

  cadastrarUsuario(){

  }

  editarUsuario(){

  }
}
