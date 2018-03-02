import { Component,OnInit } from '@angular/core';
import { Http  } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  produtos : any = null;

  constructor(private _http: Http){

  }

  ngOnInit(){
    this._http.get("/api/produto").subscribe(result => 
    this.produtos = result.json());
  }

}
