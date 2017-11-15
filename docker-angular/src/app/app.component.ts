import { Component } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';

  API = 'http://localhost:8080';

  values: any[] = [];

  constructor(private http: Http) { }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get(`${this.API}/api/values`)
      .map(res => res.json())
      .subscribe(values => {
        console.log(values);
        this.values = values;
      });

  }
}
