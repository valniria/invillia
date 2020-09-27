import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './compartilhado/componentes/dashboard/dashboard.component';
import { JogosComponent } from './jogos/jogos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { JogoNovoComponent } from './jogos/jogo-novo/jogos-novo.component';
import { UsuarioNovoComponent } from './usuarios/usuario-novo/usuario-novo.component';
import { LoginComponent } from './usuarios/login/login.component';
import { RegistroComponent } from './usuarios/registro/registro.component';
import { UsuarioDetalhesComponent } from './usuarios/usuario-detalhes/usuario-detalhes.component';
import { JogoDetalhesComponent } from './jogos/jogo-detalhes/jogo-detalhes.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: DashboardComponent },
  { path: 'jogos', component: JogosComponent },
  { path: 'jogo-novo/:jogoId', component: JogoNovoComponent },
  { path: 'jogo-novo', component: JogoNovoComponent },
  { path: 'usuarios', component: UsuariosComponent },
  { path: 'usuario-novo', component: UsuarioNovoComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegistroComponent },
  { path: 'usuario-detalhes/:usuarioId', component: UsuarioDetalhesComponent },
  { path: 'jogo-detalhes/:jogoId', component: JogoDetalhesComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
