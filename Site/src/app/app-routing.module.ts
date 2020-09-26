import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './compartilhado/componentes/dashboard/dashboard.component';
import { JogosComponent } from './jogos/jogos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { JogoNovoComponent } from './jogos/jogo-novo/jogos-novo.component';
import { UsuarioNovoComponent } from './usuarios/usuario-novo/usuario-novo.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: DashboardComponent },
  { path: 'jogos', component: JogosComponent },
  { path: 'jogo-novo/:jogoId', component: JogoNovoComponent },
  { path: 'jogo-novo', component: JogoNovoComponent },
  { path: 'usuarios', component: UsuariosComponent },
  { path: 'usuario-novo', component: UsuarioNovoComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
