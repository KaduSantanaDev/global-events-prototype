import { ContactsComponent } from './components/contacts/contacts.component';
import { TitleComponent } from './shared/title/title.component';
import { DateFormatPipe } from './helpers/DateFormat.pipe';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './components/events/events.component';
import { PanelistsComponent } from './components/panelists/panelists.component';
import { NavComponent } from './shared/nav/nav.component';

import { ModalModule } from 'ngx-bootstrap/modal'

import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse'
import { FormsModule } from '@angular/forms';
import { EventService } from './services/event.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';

@NgModule({
  declarations: [
    AppComponent,
      EventsComponent,
      PanelistsComponent,
      NavComponent,
      DateFormatPipe,
      TitleComponent,
      ContactsComponent,
      DashboardComponent,
      PerfilComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
  ],
  providers: [
    EventService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
