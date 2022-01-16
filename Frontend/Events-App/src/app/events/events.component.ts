import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = []
  public filteredEvents: any = []
  showImg = true
  private _listFilter = ''

  public get listFilter() {
    return this._listFilter
  }

  filterEvents(filterBy: string): any {
    filterBy = filterBy.toLowerCase()
    return this.events.filter(
      (e: any) => e.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      e.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  public set listFilter(value: string) {
    this._listFilter = value
    this.filteredEvents = this.listFilter ? this.filterEvents(this.listFilter) : this.events
  }



  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos()
  }

  changeImgState() {
    this.showImg = !this.showImg
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Event').subscribe(
      response => {
        this.events = response
        this.filteredEvents = this.events
      },
      error => console.log(error)

    )
  }

}
