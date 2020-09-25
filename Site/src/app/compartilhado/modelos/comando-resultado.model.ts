export class ComandoResultado {
    sucesso: boolean;
    mensagem: string;
    data: object;
    totalDeRegistros: number;
}

export class ComandoResultadoPaginado extends ComandoResultado {
    totalDeRegistros: number;
}