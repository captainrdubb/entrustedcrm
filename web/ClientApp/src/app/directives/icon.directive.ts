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
  static CREATE_ICON: string = 'plus';

  static classMap: { [key: string]: string } = {
    [IconDirective.ACCEPT_ICON]: 'accept-icon',
    [IconDirective.CANCEL_ICON]: 'cancel-icon',
    [IconDirective.DELETE_ICON]: 'delete-icon',
    [IconDirective.EDIT_ICON]: 'edit-icon',
    [IconDirective.CREATE_ICON]: 'create-icon',
  }

  @Input() appIcon: string;
  @Input() iconWidth: string = '16px';

  constructor(private elementRef: ElementRef, private renderer: Renderer2) { }

  ngOnInit(): void {
    const el: HTMLElement = this.elementRef.nativeElement;
    el.innerHTML = octicons[this.appIcon].toSVG({ 'width': this.iconWidth, class: IconDirective.classMap[this.appIcon] });
  }
}