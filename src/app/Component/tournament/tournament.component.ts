import { Component, OnInit } from '@angular/core';
import { Sport } from 'src/app/Models/Sport';
import { Country } from 'src/app/Models/Country';
import { Tournament} from 'src/app/Models/Tournament';
import { CountryService } from 'src/app/Service/country.service';
import { SportService } from 'src/app/sport.service';
import { TournamentService } from 'src/app/Service/tournament.service';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.css']
})
export class TournamentComponent implements OnInit {
  tournament : Tournament[];
  sport : Sport[];
  country: Country[]; 
  countryTemp : Country[];
  sportId:number;
  countryID: number;
  isSelected : Boolean=false; 

  constructor(private tournamentService : TournamentService, private countryService: CountryService, private sportService: SportService) { }

  ngOnInit() {
 this.getAllCountries();
 this.getSport();
 this.getAllTournament();
//  console.log(this.tournament);
  }

  getSport(){this.sportService.GetAllSPort().subscribe( sport =>{this.sport= sport;
       console.log(sport);
    });
   
    }
  getAllCountries()
  {
  this.countryService.GetAllCountries().subscribe(country=>{this.country = country});
  }
  getAllTournament()
  {
  this.tournamentService.GetAllTournament().subscribe(tournament=>{this.tournament = tournament});
  console.log(this.tournament);
  }

GetSportId(value)
{
this.sportId = value;
// console.log(value);
this.countryTemp = [];
for(var x=0;x<this.country.length;x++)
{
  if(this.country[x].sportID==this.sportId)
  {
     this.countryTemp.push(this.country[x]);
  }
}}

GetcountryId(value)
{
this.countryID = value;
// console.log(value);
this.isSelected=true;
return value ;
}
 AddTournament(tournamentName: string, sportID: number, countryID: number): void 
 {
   if (!tournamentName || sportID == undefined || countryID == undefined) { return; }

  this.tournamentService.AddTournament({tournamentName, sportID,countryID } as Tournament).subscribe((tournament : Tournament)=> this.tournament.push(tournament));

} 
   removeTournament(Tournament : Tournament):void
  {
    this.tournamentService.DeleteTournament(Tournament).subscribe((tournament: Tournament[]) =>this.tournament = tournament);
  }

  editTournament(tournamentID :number,tournamentName:string) 
  {
  // console.log(this.tournament);
  this.tournamentService.EditTournament({tournamentID, tournamentName} as Tournament).subscribe((tournament : Tournament[])=> this.tournament =tournament);  
  }

 
}