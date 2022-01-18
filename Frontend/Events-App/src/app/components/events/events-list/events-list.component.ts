import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EventService } from 'src/app/services/event.service';
import { Event } from '../../../model/Event';


@Component({
  selector: 'app-events-list',
  templateUrl: './events-list.component.html',
  styleUrls: ['./events-list.component.scss']
})
export class EventsListComponent implements OnInit {

  modalRef?: BsModalRef

  public events: Event[] = []
  public filteredEvents: Event[] = []
  showImg = true
  private _listFilter: string = ''

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
  ) { }

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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
