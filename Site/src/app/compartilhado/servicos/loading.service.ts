import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  loading: BehaviorSubject<number> = new BehaviorSubject<number>(0);

  public mostrarLoading() {
      this.loading.next(this.loading.value + 1);
  }

  public removerLoading() {
      this.loading.next(this.loading.value > 0 ? this.loading.value - 1 : 0);
  }

}