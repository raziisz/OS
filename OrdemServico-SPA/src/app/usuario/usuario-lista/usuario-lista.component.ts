import { AlertifyService, UsuarioService } from '../../_services/index'
import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/_models';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.css']
})
export class UsuarioListaComponent implements OnInit {
  usuarios: Usuario[];

  constructor(public alertify: AlertifyService, public usuarioService: UsuarioService,
    public route: ActivatedRoute) { }

  ngOnInit() {
    this.carregarUsuarios();
  }

  carregarUsuarios() {
    this.usuarioService.getUsuarios().subscribe((res: Usuario[]) => {
      this.usuarios = res;
    }, error => {
      this.alertify.error(error);
    });
  }

}
