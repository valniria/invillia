import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './compartilhado/componentes/header/header.component';
import { FooterComponent } from './compartilhado/componentes/footer/footer.component';
import { SidebarComponent } from './compartilhado/componentes/sidebar/sidebar.component';
import { DashboardComponent } from './compartilhado/componentes/dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { AppInitService } from './compartilhado/servicos/app-init.service';
import { httpInterceptorProviders } from './compartilhado/componentes/http-interceptors';
import { JogosComponent } from './jogos/jogos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { JogoNovoComponent } from './jogos/jogo-novo/jogos-novo.component';
import { UsuarioNovoComponent } from './usuarios/usuario-novo/usuario-novo.component';
import { LoginComponent } from './usuarios/login/login.component';
import { RegistroComponent } from './usuarios/registro/registro.component';
import { UsuarioDetalhesComponent } from './usuarios/usuario-detalhes/usuario-detalhes.component';
import { JogoDetalhesComponent } from './jogos/jogo-detalhes/jogo-detalhes.component';
import { LoadingComponent } from './compartilhado/componentes/loading/loading.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { MensagemComponent } from './compartilhado/componentes/mensagem/mensagem.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    JogosComponent,
    UsuariosComponent,
    JogoNovoComponent,
    UsuarioNovoComponent,
    LoginComponent,
    RegistroComponent,
    UsuarioDetalhesComponent,
    JogoDetalhesComponent,
    LoadingComponent,
    MensagemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SweetAlert2Module.forRoot()
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      multi: true,
      deps: [AppInitService],
      useFactory: (appConfigService: AppInitService) => {
        return () => {
          return appConfigService.carregarConfiguracoesDoApp();
        };
      }
    },
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
