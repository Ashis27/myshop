import { Component } from '@angular/core';
import { ConfigService } from './shared/services/config.service';
import { Subscription } from 'rxjs';
import { AuthService } from './shared/authentication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  name: string;
  isAuthenticated: boolean;
  subscription:Subscription;
  
  constructor(private configService: ConfigService,private authService:AuthService) {
    this.subscription = this.authService.authNavStatus$.subscribe(status =>{
       this.isAuthenticated = status;
       this.name = this.authService.name;
    });

    this.configService.load();
  }

   async signout() {
    await this.authService.signout();     
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }
}
