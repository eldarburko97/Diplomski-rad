import { Component } from '@angular/core';
import { OnInit } from '@angular/core';

declare var Collapse: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit  {
  ngOnInit(): void {
    new Collapse();
  }
  title = 'AdminUI';

 
  onClick(target):void {
    let toggle = target;
    let navigation = document.querySelector('.navigation');
    let main = document.querySelector('.main');
    toggle.classList.toggle('active');
    navigation.classList.toggle('active');
    main.classList.toggle('active');
  }


}


