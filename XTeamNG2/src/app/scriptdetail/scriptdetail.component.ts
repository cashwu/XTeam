import { Component, OnInit, Input } from '@angular/core';
import { Script } from './../scripts.service';

@Component({
    selector: 'app-scriptdetail',
    templateUrl: './scriptdetail.component.html',
    styleUrls: ['./scriptdetail.component.css']
})
export class ScriptdetailComponent implements OnInit {

    @Input()
    Content: string;
    config : Object;

    constructor() {
    }

    ngOnInit() {
    }

    onCopyClick(){
      alert("OK !!");
    }
}
