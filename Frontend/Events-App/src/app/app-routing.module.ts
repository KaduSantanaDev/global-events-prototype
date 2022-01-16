import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PanelistsComponent } from './components/panelists/panelists.component';
import { PerfilComponent } from './components//perfil/perfil.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components//dashboard/dashboard.component';
import { EventsComponent } from './components/events/events.component';


const routes: Routes = [
  {
    path: 'eventos',
    component: EventsComponent,
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'contatos',
    component: ContactsComponent,
  },
  {
    path: 'perfil',
    component: PerfilComponent,
  },
  {
    path: 'palestrantes',
    component: PanelistsComponent,
  },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
