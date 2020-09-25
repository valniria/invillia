export class FiltroPesquisaBase {
    pagina: number;
    elementosPorPagina: number;

    constructor(){
        this.pagina = 1;
        this.elementosPorPagina = 10;
    }
}