import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { UsuarioListaComponent } from './usuario/usuario-lista/usuario-lista.component';
import { UsuarioListaResolver } from './_resolvers/usuario-lista.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        {path: 'usuarios', component: UsuarioListaComponent, resolve: {usuarios: UsuarioListaResolver}}
        // { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
        // { path: 'members/:id', component: MemberDetailComponent,
        //  resolve: {user: MemberDetailResolver}},
        // {path: 'member/edit', component: MemberEditComponent,
        //   resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
        // { path: 'messages', component: MessagesComponent},
        // { path: 'lists', component: ListsComponent},
      ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];