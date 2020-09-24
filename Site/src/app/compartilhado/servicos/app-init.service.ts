import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppInitService {

  private appConfig: any;

  constructor(private http: HttpClient) { }

  carregarConfiguracoesDoApp() {
    return this.http.get('../../../assets/appsettings.json')
      .toPromise()
      .then(data => {
        this.appConfig = data;
      });
  }


  public retornarConfiguracao() {
    if (!this.appConfig) {
      throw Error('Ocorreu um erro na configuração.');
    }

    return this.appConfig;
  }
  
}
