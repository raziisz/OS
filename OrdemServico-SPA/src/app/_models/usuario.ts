import { Servico } from './index';

export interface Usuario {
    id: number;
    login?: string;
    senha?: string;
    nome: string;
    departamentoId?: number;
    departamentoDescricao?: string;
    cargo: string;
    servicos?: Servico[];
}
