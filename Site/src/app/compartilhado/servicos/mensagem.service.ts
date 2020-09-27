import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class MensagemService {

  constructor(private toastr: ToastrService) { }

  private configuracaoDeMensagem: any = {
    closeButton: true,
    progressAnimation: 'increasing',
    progressBar: true,
    enableHtml: true,
    tapToDismiss:true
  };

  mostrarMensagemDeSucesso(titulo: string, texto: string) {
    this.toastr.success(texto, titulo, this.configuracaoDeMensagem);
  }

  mostrarMensagemDeErro(titulo: string, texto: string) {
    this.toastr.error(texto, titulo, this.configuracaoDeMensagem);
  }
 
}
