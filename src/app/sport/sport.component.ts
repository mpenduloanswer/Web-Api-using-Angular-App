import { Component, OnInit, EventEmitter,Output,Input } from '@angular/core';
import { Sport} from '../Models/Sport';
import { SportService } from '../sport.service';

@Component({
  selector: 'app-sport',
  templateUrl: './sport.component.html',
  styleUrls: ['./sport.component.css']

})
export class SportComponent implements OnInit {
@Input() currentSport:Sport;
@Output() newSport: EventEmitter<Sport> = new EventEmitter();
values : Sport[];
// sportName: string;
  constructor(private sportService: SportService) { }

  ngOnInit() {
    this.getSport();
     
  }
  getSport(){
  
   this.sportService.GetAllSPort().subscribe(values =>this.values =values);
  
  }
  
AddSports(sportName: string): void {
  
  var sportOne: Sport = { sportID: 0, SportName: sportName };
  console.log(sportOne);
  this.sportService.addSport((sportOne) as Sport).subscribe();
  setTimeout(()=> this.getSport(),50);​ 
  }

removeSport(Sport):void{
  this.sportService.DeleteSport(Sport).subscribe(Sport=>{this.ngOnInit()});
}

editSports(Sport :Sport,sportName:string) {
  Sport.SportName=sportName;
   this.sportService.editSport((Sport) as Sport).subscribe(
     Sport=>{this.ngOnInit()});
}
  }

