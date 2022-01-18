import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() title: string = ''
  @Input() iconClass = 'fa fa-user'
  @Input() subtitle = 'Since 2022'
  @Input() listButton = false
  constructor(private router: Router) { }

  ngOnInit() {
  }

  list() {
    this.router.navigate([`/eventos/lista`])
  }

}
