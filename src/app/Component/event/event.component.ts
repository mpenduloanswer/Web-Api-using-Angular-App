import { Component, OnInit } from '@angular/core';
import { TournamentService } from 'src/app/Service/tournament.service';
import { CountryService } from 'src/app/Service/country.service';
import { SportService } from 'src/app/sport.service';
import { EventsService } from 'src/app/Service/events.service';
import { Tournament } from 'src/app/Models/Tournament';
import { Sport } from 'src/app/Models/Sport';
import { Country } from 'src/app/Models/Country';
import { Events } from 'src/app/Models/Events';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  tournament: Tournament[];
  sport: Sport[];
  country: Country[];
  countryTemp: Country[];
  tournamentTemp: Tournament[];
  sportTemp: Sport[];
  sportId: number;
  countryID: number;
  tournamentid: number;
  events: Events[];



  constructor(private sportService: SportService, private countryService: CountryService, private tournaService: TournamentService, private eventService: EventsService) { }

  ngOnInit() {
    this.getSport();
    this.getAllCountries();
    this.getAllTournament();
    this.getAllEvents();
  
  }
  getSport() {
    this.sportService.GetAllSPort().subscribe(sport => {
    this.sport = sport;
      // console.log(sport);
    });
  }

  getAllCountries() {
    this.countryService.GetAllCountries().subscribe(country => { this.country = country });
  }

  GetSportId() {
    this.sportId = +this.sportId;
    // console.log(this.sportId);
    this.countryTemp = [];
    for (var x = 0; x < this.country.length; x++) {
      if (this.country[x].sportID == this.sportId) {

        this.countryTemp.push(this.country[x]);
      }
    }
  }

  GetcountryId() {
    this.countryID = +this.countryID;
    // console.log(this.countryID);
    this.tournamentTemp = [];

    for (var x = 0; x < this.tournament.length; x++) {
      // console.log(this.tournament[x].countryID);
      if (this.tournament[x].countryID == this.countryID) {
        this.tournamentTemp.push(this.tournament[x]);

      }

    }
  }

  GetTournamentId() {
    this.tournamentid = +this.tournamentid;
    console.log(this.tournamentid);
  }
  postEvents(eventName: string, sportID: number, countryID: number, tournamentid, eventDate: Date): void {
        eventName = eventName.trim()
        console.log(eventDate);
    if (!eventName || sportID == undefined || countryID == undefined || tournamentid == undefined || !eventDate) {
       
      return; }
      
    this.eventService.addEvent({eventName,sportID,countryID,tournamentid, eventDate } as Events).subscribe(
      Event=>{this.ngOnInit()},(event: Events) => {
      this.events.push(event);
    });
  }
  getAllEvents(): void {
     this.eventService.GetAllEvents().subscribe(events =>{this.events = events});
  }
 
  getAllTournament() {
    this.tournaService.GetAllTournament().subscribe(tournament => { this.tournament = tournament });
  }

  removeEvent(event: Events): void {
    if (!event) { return; }

    if (confirm("Are You Sure You Want To Delete " + event.eventName)) {
      this.eventService.deleteEvent(event).subscribe((event: Events[]) => {
        this.events = event
      }, (error: any) => {

      });
      console.log(event);
    }
  }
  editEvent( eventID: number,eventName: string, eventDate : Date): void {
    if (!eventName) { return; }
    this.eventService.editEvent({ eventID, eventName ,eventDate} as Events).subscribe((event: Events[]) => {
      this.events = event
    }, (error: any) => {

    });
  }
}
