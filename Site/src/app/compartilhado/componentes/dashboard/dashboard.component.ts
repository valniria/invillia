import { Component, OnInit } from '@angular/core';
import { LoadingService } from '../../servicos/loading.service';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  dadosDashboard:any = {
    quantidadeDeJogos: 0,
    porcentagemDeEmprestimo: 0,
    usuariosCadastrados: 0
  }
  constructor(
    private loadingService: LoadingService,
    private servico: DashboardService
    ) { }

  ngOnInit(): void {
    this.carregarDashboard();
  }

  carregarDashboard(){
    this.loadingService.mostrarLoading();
    this.servico.carregarDashboard().subscribe(
      (res) => {
        this.dadosDashboard = res.data;
        this.loadingService.removerLoading();
      },
      (error) => {
        this.loadingService.removerLoading();
      }
    );
  }
}
