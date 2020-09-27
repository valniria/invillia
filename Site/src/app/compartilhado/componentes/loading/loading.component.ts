import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadingService } from '../../servicos/loading.service';

@Component({
  selector: 'ni-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent  {

  public contadorDeLoading$: Observable<number>;
    constructor(private loadingService: LoadingService) {
        this.contadorDeLoading$ = loadingService.loading.asObservable();
    }
}
