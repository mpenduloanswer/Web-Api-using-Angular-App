import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SportComponent } from './sport/sport.component';
import { TournamentComponent } from './Component/tournament/tournament.component';
import { EventComponent } from './Component/event/event.component';
import { CountryComponent } from './Component/country/country.component';
import { HomeComponent } from './Component/home/home.component';

const routes: Routes = [
{
  path :'sport',
  component :SportComponent
},
{
  path : 'tournament',
  component : TournamentComponent
},
{
  path :'event',
  component : EventComponent
},
{
  path :'country',
  component : CountryComponent
},
{
  path :'home',
  component : HomeComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
