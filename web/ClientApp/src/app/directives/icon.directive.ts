import { Directive, Input, OnInit, ElementRef, Renderer2 } from '@angular/core';

import * as octicons from 'octicons';

@Directive({
  selector: '[appIcon]'
})
export class IconDirective implements OnInit {

  static ACCEPT_ICON: string = 'check';
  static CANCEL_ICON: string = 'x';
  static DELETE_ICON: string = 'trashcan';
  static EDIT_ICON: string = 'pencil';
  static PLUS_ICON: string = 'plus';

  @Input() appIcon: string;

  constructor(private elementRef: ElementRef, private renderer: Renderer2) { }

  ngOnInit(): void {
    const el: HTMLElement = this.elementRef.nativeElement;
    el.innerHTML = octicons[this.appIcon].toSVG();
  }
}