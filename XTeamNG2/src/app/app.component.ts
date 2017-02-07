import { Component } from '@angular/core';
import { ScriptsService } from './scripts.service';
import { Script } from './scripts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'app works!';

  scriptContent: string;

  constructor(private scriptSvc: ScriptsService) {

  }

  ngOnInit() {
  }

  onNotify(script: Script) {
    this.scriptContent = script ? script.Script : "";
  }
}
