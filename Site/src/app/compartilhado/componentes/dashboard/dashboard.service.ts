import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppInitService } from '../../servicos/app-init.service';
import { Observable } from 'rxjs';
import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  protected readonly variavelDeAmbiente;
  constructor(
    private appInitService: AppInitService,
    private httpClient: HttpClient
  ) {
    this.appInitService.carregarConfiguracoesDoApp();
    this.variavelDeAmbiente = this.appInitService.retornarConfiguracao();
  }

  carregarDashboard(): Observable<any> {
    return this.httpClient.get(this.variavelDeAmbiente.APIUrlBase + `home`);
  }

}