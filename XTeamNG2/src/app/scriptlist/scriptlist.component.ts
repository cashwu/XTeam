import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ScriptsService } from './../scripts.service';
import { Script } from './../scripts.service';

@Component({
    selector: 'app-scriptlist',
    templateUrl: './scriptlist.component.html',
    styleUrls: ['./scriptlist.component.css'],
    providers: [ScriptsService]
})
export class ScriptlistComponent implements OnInit {

    filter: string;

    // @Input()
    selected: Script;

    @Output()
    selectedChange: EventEmitter<Script> = new EventEmitter();

    constructor(private scriptSvc: ScriptsService) {
    }

    ngOnInit() {
    }

    doFilter() {
        this.scriptSvc.doSearch(this.filter);
    }

    onClick(script : Script){
        this.selected = script;
        this.selectedChange.emit(script);
    }
}
