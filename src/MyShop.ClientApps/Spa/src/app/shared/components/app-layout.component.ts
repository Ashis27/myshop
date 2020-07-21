import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../services/config.service';

@Component({
  selector: 'app-layout-cmp',
  template: ``
})
// <app-header-cmp></app-header-cmp>
export class AppLayoutComponent implements OnInit {

  constructor(private configService: ConfigService) { 

  }

  ngOnInit(): void {
    this.configService.load();
  }

}
