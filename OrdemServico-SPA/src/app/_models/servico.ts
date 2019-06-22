import { ServicoStatus } from './index';

export interface Servico {
    id: number;
    descricao: string;
    tipoOrdem: string;
    status: ServicoStatus;
    dataRegistro: Date;
    dataFinalizada?: Date;
    usuarioId: number;
}
