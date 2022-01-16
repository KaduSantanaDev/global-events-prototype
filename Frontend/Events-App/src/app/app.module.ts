import { DateFormatPipe } from './helpers/DateFormat.pipe';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './components/events/events.component';
import { PanelistsComponent } from './components/panelists/panelists.component';
import { NavComponent } from './components/nav/nav.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse'
import { FormsModule } from '@angular/forms';
import { EventService } from './services/event.service';

@NgModule({
  declarations: [
    AppComponent,
      EventsComponent,
      PanelistsComponent,
      NavComponent,
      DateFormatPipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
  ],
  providers: [
    EventService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
