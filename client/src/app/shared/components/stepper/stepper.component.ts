import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.scss'],
  providers: [
    {provide: CdkStepper, useExisting: StepperComponent}
  ]
})
export class StepperComponent extends CdkStepper implements OnInit {
  // @Input(): properties we want to receive from client
  // For more examples: https://angular.io/api/core/Input
  @Input() linearModeSelected: boolean;

  ngOnInit(): void {
    this.linear = this.linearModeSelected;
  }

  onClick(index: number) {
    this.selectedIndex = index;
    console.log(this.selectedIndex);
  }

}
