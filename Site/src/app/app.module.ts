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
import { AmigosComponent } from './amigos/amigos.component';
import { UsuariosComponent } from './usuarios/usuarios.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    JogosComponent,
    AmigosComponent,
    UsuariosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
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
