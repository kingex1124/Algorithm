window.onload = function () {
    let n1 = new ListNode(4);
    n1.next = new ListNode(1);

    n1.next.next = new ListNode(8);
    n1.next.next.next = new ListNode(4);
    n1.next.next.next.next = new ListNode(5);

    let n2 = new ListNode(5);
    n2.next = new ListNode(0);
    n2.next.next = new ListNode(1);
    n2.next.next.next = new ListNode(8);
    n2.next.next.next.next = new ListNode(4);
    n2.next.next.next.next.next = new ListNode(5);

    let ressult = getIntersectionNode(n1, n2);
}

var getIntersectionNode = function (headA, headB) {
    let a1 = headA;
    let b2 = headB;

    while (a1 != b2) {
        a1 = a1 === null ? headB : a1.next;
        b2 = b2 === null ? headA : b2.next;
    }

    return a1;
};

function ListNode(val) {
  this.val = val;
  this.next = null;
  }