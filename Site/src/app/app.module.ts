import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AppInitService } from './compartilhado/servicos/app-init.service';

@NgModule({
  declarations: [
    AppComponent
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
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
