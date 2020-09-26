import { Component, OnInit } from '@angular/core';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  dadosDashboard:any = {
    quantidadeDeJogos: 10,
    porcentagemDeEmprestimo: 22,
    usuariosCadastrados: 2
  }
  constructor(
    private servico: DashboardService
    ) { }

  ngOnInit(): void {
    this.carregarDashboard();
  }

  carregarDashboard(){
    debugger;
    this.servico.carregarDashboard().subscribe(
      (res) => {
        debugger;
        this.dadosDashboard = res.data;
        console.log('dentro');
      },
      (error) => {
        console.log('erro');
      }
    );
  }
}
