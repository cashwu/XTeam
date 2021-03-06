import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class ScriptsService {

  data: Script[];
  odata: Script[];

  constructor(private http: Http) {
    this.http.get("/api/scriptapi/GetAll")
      .map((res) => res.json())
      .subscribe((value) => {
        this.data = value;
        this.odata = value;
      });
  }

  doSearch(filter: string) {
    this.data = this.odata;

    this.data = this.data.filter((value) => {
      return value.Name.toLocaleLowerCase().indexOf(filter.toLocaleLowerCase()) > -1;
    });
  }
}

export class Script {
  Id: string;
  Name: string;
  SqlCommand: string;
  CreatedBy: string;
  CreatedOn: Date;
  ModifiedBy: string;
  ModifiedOn: Date;
}
