import { Event } from './../../model/Event';
import { EventService } from './../../services/event.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: Event[] = []
  public filteredEvents: Event[] = []
  showImg = true
  private _listFilter: string = ''

  public get listFilter() {
    return this._listFilter
  }

  public set listFilter(value: string) {
    this._listFilter = value
    this.filteredEvents = this.listFilter ? this.filterEvents(this.listFilter) : this.events
  }

  filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLowerCase()
    return this.events.filter(
      (e: any) => e.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      e.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private eventService: EventService) { }

  ngOnInit() {
    this.getEventos()
  }

  changeImgState(): void {
    this.showImg = !this.showImg
  }

  public getEventos(): void {
    this.eventService.getEvents().subscribe(
      (_events: Event[]) => {
        this.events = _events
        this.filteredEvents = this.events
      },
      error => console.log(error)

    )
  }

}
