import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sach',
  templateUrl: './sach.component.html',
  styleUrls: ['./sach.component.css']
})
export class SachComponent implements OnInit {
  public res: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post('https://localhost:44330/' + 'api/Sach/get-all',null).subscribe(result => {
      this.res = result;
      console.log(this.res);
    }, error => console.error(error));
  }
  ngOnInit() {
  
  }
}

  


