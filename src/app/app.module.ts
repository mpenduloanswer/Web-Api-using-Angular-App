import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SportComponent } from './sport/sport.component';
import { TournamentComponent } from './Component/tournament/tournament.component';
import { EventComponent } from './Component/event/event.component';
import { CountryComponent } from './Component/country/country.component';
import { HttpClientModule } from '@angular/common/http';
import { SportService } from './sport.service';
import {CountryService} from './Service/country.service'
import {FormsModule} from '@angular/forms';
import { from } from 'rxjs';
import { HomeComponent } from './Component/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SportComponent,
    TournamentComponent,
    EventComponent,
    CountryComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [SportService,CountryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
